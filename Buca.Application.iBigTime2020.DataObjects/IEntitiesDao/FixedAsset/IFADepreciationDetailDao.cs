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
    /// IFADepreciationDetailDao
    /// </summary>
    public interface IFADepreciationDetailDao
    {
        /// <summary>
        /// Gets the fa armortization details by fa armortization.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        List<FADepreciationDetailEntity> GetFADepreciationDetailsByFADepreciation(string refId);

        /// <summary>
        /// Gets the fa devaluation details by fa depreciation.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        List<FADepreciationDetailEntity> GetFADevaluationDetailsByFADepreciation(string refId);

        /// <summary>
        /// Gets the fa depreciation details by fa depreciation.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>List&lt;FADepreciationDetailEntity&gt;.</returns>
        List<FADepreciationDetailEntity> GetFADepreciationDetailsByFADepreciation(DateTime fromDate, DateTime toDate);

        List<FADepreciationDetailEntity> GetFADepreciationDetailsByFADepreciation(DateTime fromDate, DateTime toDate, int periodType);

        /// <summary>
        /// Gets the fa decrement by fa increment.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        List<FADepreciationDetailEntity> GetFADepreciationByFAIncrement(string refId);

        /// <summary>
        /// Gets the automatic fa armortization details by currency code.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="yearOfDeprecation">The year of deprecation.</param>
        /// <returns></returns>
        List<FADepreciationDetailEntity> GetAutoFADepreciationDetailsByCurrencyCode(string currencyCode, int yearOfDeprecation);

        /// <summary>
        /// Inserts the fa armortization detail.
        /// </summary>
        /// <param name="fAArmortizationDetail">The f a armortization detail.</param>
        /// <returns></returns>
        string InsertFADepreciationDetail(FADepreciationDetailEntity fAArmortizationDetail);

        /// <summary>
        /// Deletes the fa armortization detail by fa armortization identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        string DeleteFADepreciationDetailByFADepreciationId(string refId);
    }
}
