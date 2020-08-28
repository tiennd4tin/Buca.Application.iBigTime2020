/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.FixedAsset;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.FixedAsset
{
    /// <summary>
    /// IFADepreciationDao
    /// </summary>
    public interface IFADepreciationDao
    {
        /// <summary>
        /// Gets the fa armortization.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        FADepreciationEntity GetFADepreciation(string refId);

        /// <summary>
        /// Gets the fa depreciation.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>FADepreciationEntity.</returns>
        FADepreciationEntity GetFADepreciation(DateTime fromDate, DateTime toDate);

        /// <summary>
        /// Gets the fa depreciation.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <returns></returns>
        FADepreciationEntity GetFADepreciation(string refNo, DateTime postedDate);

        /// <summary>
        /// Gets the fa armortizations by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        List<FADepreciationEntity> GetFADepreciationsByRefTypeId(int refTypeId);

        /// <summary>
        /// Gets the fa depreciations by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="postedYear">The posted year.</param>
        /// <returns></returns>
        List<FADepreciationEntity> GetFADepreciationsByRefTypeId(int refTypeId, int postedYear);

        /// <summary>
        /// Gets the type of the fa depreciations by reference type and period.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="periodType">Type of the period.</param>
        /// <returns></returns>
        List<FADepreciationEntity> GetFADepreciationsByRefTypeAndPeriodType(int refTypeId, DateTime refDate, int periodType);

        /// <summary>
        /// Gets the type of the fa depreciations by reference type and period.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="periodType">Type of the period.</param>
        /// <returns></returns>
        List<FADepreciationEntity> GetFADevaluationsByRefDateAndPeriodType(int refTypeId, DateTime refDate, int periodType);

        /// <summary>
        /// Gets the fa armortizations.
        /// </summary>
        /// <returns></returns>
        List<FADepreciationEntity> GetFADepreciations();

        /// <summary>
        /// Gets the fa armortizations by reference date.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        List<FADepreciationEntity> GetFADepreciationsByRefDate(DateTime refDate);

        /// <summary>
        /// Gets the fa armortizations by reference date.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        List<FADepreciationEntity> GetFADepreciationsByRefDate(DateTime refDate, string currencyCode);
        
        /// <summary>
        /// Inserts the fa armortization.
        /// </summary>
        /// <param name="fAArmortization">The f a armortization.</param>
        /// <returns></returns>
        string InsertFADepreciation(FADepreciationEntity fAArmortization);

        /// <summary>
        /// Updates the fa armortization.
        /// </summary>
        /// <param name="fAArmortization">The f a armortization.</param>
        /// <returns></returns>
        string UpdateFADepreciation(FADepreciationEntity fAArmortization);

        /// <summary>
        /// Deletes the fa armortization.
        /// </summary>
        /// <param name="fAArmortization">The f a armortization.</param>
        /// <returns></returns>
        string DeleteFADepreciation(FADepreciationEntity fAArmortization);
    }
}
