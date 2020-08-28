/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: November 20, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    20/11/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.General;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.General
{
    /// <summary>
    /// IGLVoucherDetailDao
    /// </summary>
    public interface IGLVoucherDetailDao
    {
        /// <summary>
        /// Gets the fa armortization details by fa armortization.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        List<GLVoucherDetailEntity> GetGLVoucherDetailsByRefId(string refId);

        List<GLVoucherDetailEntity> GetGLVoucherDetailsEarlyYear(DateTime date);
        List<GLVoucherDetailEntity> GetGLVoucherExpensesWaitingSettlement(DateTime date, string projectIds = null);
        List<GLVoucherDetailEntity> GetGLSettlementOfCompletedProjects(DateTime date, string projectIds);

        List<GLVoucherDetailEntity> GetGLVoucherDetailsEndYear(DateTime date);

        List<GLVoucherDetailEntity> GetGLVoucherDetailsPerformanceResults(DateTime date);

        /// <summary>
        /// Gets the fa decrement by fa increment.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        List<GLVoucherDetailEntity> GetGLVoucherDetailByGLVoucher(string refId);

        /// <summary>
        /// Gets the automatic fa armortization details by currency code.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="yearOfDeprecation">The year of deprecation.</param>
        /// <returns></returns>
        List<GLVoucherDetailEntity> GetAutoGLVoucherDetailsByCurrencyCode(string currencyCode, int yearOfDeprecation);

        /// <summary>
        /// Inserts the fa armortization detail.
        /// </summary>
        /// <param name="glVoucherDetail">The f a armortization detail.</param>
        /// <returns></returns>
        string InsertGLVoucherDetail(GLVoucherDetailEntity glVoucherDetail);

        /// <summary>
        /// Deletes the fa armortization detail by fa armortization identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        string DeleteGLVoucherDetailByRefId(string refId);
    }
}
