/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{

    /// <summary>
    /// IVoucherListDao interface
    /// </summary>
    public interface IVoucherListDao
    {
        /// <summary>
        /// Gets the specified cus identifier.
        /// </summary>
        /// <param name="voucherListId">The voucher list identifier.</param>
        /// <returns></returns>
        VoucherListEntity GetVoucherListById(string voucherListId);

        /// <summary>
        /// Getses this instance.
        /// </summary>
        /// <returns></returns>
        List<VoucherListEntity> GetVoucherLists();

        /// <summary>
        /// Gets the voucher lists by code.
        /// </summary>
        /// <param name="voucherListCode">The voucher list code.</param>
        /// <returns></returns>
        VoucherListEntity GetVoucherListsByCode(string voucherListCode);

        /// <summary>
        /// Inserts the specified object.
        /// </summary>
        /// <param name="voucherListEntity">The voucher list entity.</param>
        /// <returns></returns>
        string InsertVoucherList(VoucherListEntity voucherListEntity);

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="voucherListEntity">The voucher list entity.</param>
        /// <returns></returns>
        string UpdateVoucherList(VoucherListEntity voucherListEntity);

        /// <summary>
        /// Deletes the specified object.
        /// </summary>
        /// <param name="voucherListEntity">The voucher list entity.</param>
        /// <returns></returns>
        string DeleteVoucherList(VoucherListEntity voucherListEntity);
    }
}
