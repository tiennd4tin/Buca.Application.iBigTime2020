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

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.General;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.General
{
    /// <summary>
    /// IGLVoucherDetailTaxDao
    /// </summary>
    public interface IGLVoucherDetailTaxDao
    {
        /// <summary>
        /// Gets the fa armortization details by fa armortization.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        List<GLVoucherDetailTaxEntity> GetGLVoucherDetailTaxesByGLVoucher(string refId);

        /// <summary>
        /// Gets the automatic fa armortization details by currency code.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="yearOfDeprecation">The year of deprecation.</param>
        /// <returns></returns>
        List<GLVoucherDetailTaxEntity> GetAutoGLVoucherDetailTaxesByCurrencyCode(string currencyCode, int yearOfDeprecation);

        /// <summary>
        /// Inserts the fa armortization detail.
        /// </summary>
        /// <param name="glVoucherDetailTax">The gl voucher detail tax.</param>
        /// <returns></returns>
        string InsertGLVoucherDetailTax(GLVoucherDetailTaxEntity glVoucherDetailTax);

        /// <summary>
        /// Deletes the fa armortization detail by fa armortization identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        string DeleteGLVoucherDetailTaxByRefId(string refId);
    }
}
