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
    /// IGLVoucherDao
    /// </summary>
    public interface IGLVoucherDao 
    {
        /// <summary>
        /// Gets the ca payment entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        GLVoucherEntity GetGLVoucherByRefId(string refId);

        /// <summary>
        /// Gets the ca payment entityby reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refType">Type of the reference.</param>
        /// <returns></returns>
        GLVoucherEntity GetGLVoucherByRefNo(string refNo, int refType);

        /// <summary>
        /// Gets the ca payment.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <returns></returns>
        GLVoucherEntity GetGLVoucher(string refNo, DateTime postedDate);

        /// <summary>
        /// Gets the bu transfer by bu transfer reference identifier.
        /// </summary>
        /// <param name="buTransferRefId">The bu transfer reference identifier.</param>
        /// <returns></returns>
        GLVoucherEntity GetGLVoucherByBUTransferRefId(string buTransferRefId);

        /// <summary>
        /// Gets the ca payment.
        /// </summary>
        /// <returns></returns>
        List<GLVoucherEntity> GetGLVouchers();

        /// <summary>
        /// Gets the ca payments by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        List<GLVoucherEntity> GetGLVouchersByRefTypeId(int refTypeId);

        /// <summary>
        /// Inserts the ca payment.
        /// </summary>
        /// <param name="glVoucher">The ca payment.</param>
        /// <returns></returns>
        string InsertGLVoucher(GLVoucherEntity glVoucher);

        /// <summary>
        /// Updates the ca payment.
        /// </summary>
        /// <param name="glVoucher">The ca payment.</param>
        /// <returns></returns>
        string UpdateGLVoucher(GLVoucherEntity glVoucher);

        /// <summary>
        /// Deletes the ca payment.
        /// </summary>
        /// <param name="glVoucher">The ca payment.</param>
        /// <returns></returns>
        string DeleteGLVoucher(GLVoucherEntity glVoucher);
        List<GLVoucherEntity> GetGLVouchersLastYearByRefTypeId(int refTypeId);
    }
}
